import 'package:flutter/material.dart';

class MessageDetails extends StatelessWidget {
  const MessageDetails({super.key, required this.id});

  final id;
  @override
  Widget build(BuildContext context) {
    return Center(
      child: Column(children: [
        Text(id.toString()),
        ElevatedButton(
            onPressed: () {
              Navigator.pop(context);
            },
            child: Text("click me")),
      ]),
    );
  }
}
