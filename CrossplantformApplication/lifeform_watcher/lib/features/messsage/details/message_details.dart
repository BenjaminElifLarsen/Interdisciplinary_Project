import 'package:flutter/material.dart';

class MessageDetails extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Center(
      child: Column(children: [
        Text("hey"),
        ElevatedButton(
            onPressed: () {
              Navigator.pop(context);
            },
            child: Text("click me")),
      ]),
    );
  }
}
