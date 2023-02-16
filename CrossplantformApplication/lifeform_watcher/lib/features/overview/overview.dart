import 'package:flutter/material.dart';
import 'package:lifeform_watcher/features/messsage/details/message_details_page.dart';
import 'package:lifeform_watcher/models/messages/message_list_item.dart';

import '../../services/message_service.dart';

class OverviewPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    //var data = fetchMessages();

    //print("test");
    //print(data);
    return Center(
      child: ListView(
        children: [
          FutureBuilder<List<MessageListItem>>(
            future: fetchMessages(),
            builder: (context, snapshot) {
              if (snapshot.hasError) {
                return const Center(
                  child: Text("Error"),
                );
              } else if (snapshot.hasData) {
                return MessageList(messages: snapshot.data!);
              } else {
                return const Center(
                  child: CircularProgressIndicator(),
                );
              }
            },
          )
        ],
      ),
    );
  }
}

class MessageList extends StatelessWidget {
  const MessageList({super.key, required this.messages});

  final List<MessageListItem> messages;
  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        for (var msg in messages) DisplayMessageListItem(msg: msg),
      ],
    );
  }
}

class DisplayMessageListItem extends StatelessWidget {
  const DisplayMessageListItem({
    super.key,
    required this.msg,
  });

  final MessageListItem msg;

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text(msg.title),
        Text(msg.text),
        ElevatedButton(
            onPressed: () {
              Navigator.push(
                  context, //seems like the widget is placed under MyApp instead under MyApp.MaterialApp.MyhomePage.LayoutBuilder.Scafforld.Row.Extended
                  MaterialPageRoute(
                      builder: (context) => MessageDetailsPage(id: msg.id)));
            },
            child: Text("Indlæs")),
      ],
    );
  }
}
