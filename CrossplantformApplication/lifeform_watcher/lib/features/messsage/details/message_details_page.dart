import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:lifeform_watcher/models/messages/message_details.dart';
import 'package:lifeform_watcher/services/message_service.dart';

class MessageDetailsPage extends StatelessWidget {
  const MessageDetailsPage({super.key, required this.id});

  final id;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      //if Center instead of Scaffold the background is black, yet this does not fix the placement problem
      body: Center(
        child: Column(children: [
          FutureBuilder<MessageDetails>(
            future: fetchMessage(id),
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
          ElevatedButton(
              onPressed: () {
                Navigator.pop(context);
              },
              child: Text("Message Overview")),
        ]),
      ),
    );
  }
}

class Details extends StatelessWidget {
  const Details({super.key, required this.message});
  final MessageDetails message;

  @override
  Widget build(BuildContext context) {
    double long = message.longtitude;
    double lati = message.latitude;
    return Column(
      children: [
        Text(message.title),
        Text(message.text),
        Text(message.time.toString()),
        Text("Latitude: $lati, longtitude: $long"),
      ],
    );
  }
}
