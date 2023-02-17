import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:lifeform_watcher/models/messages/message_details.dart';
import 'package:lifeform_watcher/models/messages/request/message_like.dart';
import 'package:lifeform_watcher/services/message_service.dart';

class MessageDetailsPage extends StatefulWidget {
  MessageDetailsPage({super.key, required this.id});

  final id;

  @override
  State<MessageDetailsPage> createState() => _MessageDetailsPageState();
}

class _MessageDetailsPageState extends State<MessageDetailsPage> {
  Future<bool>? futureLike;
  MessageLike? request;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      //if Center instead of Scaffold the background is black, yet this does not fix the placement problem
      body: Center(
        child: Column(children: [
          ElevatedButton(
              onPressed: () {
                Navigator.pop(context);
              },
              child: Text("Message Overview")),
          (futureLike == null) ? likePost() : buildFutureBuilder(),
          FutureBuilder<MessageDetails>(
            future: fetchMessage(widget.id),
            builder: (context, snapshot) {
              if (snapshot.hasError) {
                return const Center(
                  child: Text("Error"),
                );
              } else if (snapshot.hasData) {
                return Details(message: snapshot.data!);
              } else {
                return const Center(
                  child: CircularProgressIndicator(),
                );
              }
            },
          ),
        ]),
      ),
    );
  }

  ElevatedButton likePost() {
    request = MessageLike(userId: 2, messageId: widget.id);
    return ElevatedButton(
        onPressed: () {
          print('like');
          setState(() {
            futureLike = postLike(request!);
          });
        },
        child: Icon(Icons.post_add));
  }

  FutureBuilder<bool> buildFutureBuilder() {
    return FutureBuilder<bool>(
        future: futureLike,
        builder: (context, snapshot) {
          if (snapshot.hasError) {
            print(snapshot.error);
            return Text("Errored");
          } else if (snapshot.hasData) {
            return Text("Posted");
          } else {
            return const CircularProgressIndicator();
          }
        });
  }
}

class Details extends StatelessWidget {
  const Details({super.key, required this.message});
  final MessageDetails message;

  @override
  Widget build(BuildContext context) {
    double long = message.longtitude;
    double lati = message.latitude;
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Column(
          children: [
            Text(message.title),
            Text(message.text),
            Text(message.time.toString()),
            Text("Latitude: $lati, longtitude: $long"),
          ],
        ),
        Column(children: [
          FutureBuilder(
              future: fetchAuthorForMessage(message.user),
              builder: (context, snapshot) {
                if (snapshot.hasError) {
                  return const Center(
                    child: Text("Error"),
                  );
                } else if (snapshot.hasData) {
                  return Text(snapshot.data!.username);
                } else {
                  return const Center(
                    child: CircularProgressIndicator(),
                  );
                }
              })
        ]),
      ],
    );
  }
}
