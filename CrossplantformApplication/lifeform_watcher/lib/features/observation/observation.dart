import 'package:flutter/material.dart';
import 'package:lifeform_watcher/models/messages/request/message_post.dart';
import 'package:lifeform_watcher/services/message_service.dart';

class ObservationPage extends StatefulWidget {
  @override
  State<ObservationPage> createState() => _ObservationPageState();
}

class _ObservationPageState extends State<ObservationPage> {
  Future<bool>? futureObservation;

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Row(
        children: [
          Text("Observation"),
          (futureObservation == null) ? PostMessage() : buildFutureBuilder()
        ],
      ),
    );
  }

  ElevatedButton PostMessage() => ElevatedButton(
      onPressed: () {
        var request = MessagePost(
            userId: 1,
            eukaryoteId: 1,
            moment: DateTime.now(),
            latitude: 25.1,
            longtitude: 10.1,
            title: "From App",
            text: "This is a test message, please ignore");
        setState(() {
          futureObservation = postMessage(request);
        });
        print(futureObservation);
      },
      child: Icon(Icons.message));

  FutureBuilder<bool> buildFutureBuilder() {
    return FutureBuilder<bool>(
        future: futureObservation,
        builder: (context, snapshot) {
          if (snapshot.hasError) {
            print(snapshot.error);
            return Text("Error");
          } else if (snapshot.hasData) {
            return Text("Posted");
          } else {
            return const CircularProgressIndicator();
          }
        });
  }
}
