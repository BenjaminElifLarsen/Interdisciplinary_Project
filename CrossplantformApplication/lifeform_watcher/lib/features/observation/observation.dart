import 'package:flutter/material.dart';
import 'package:lifeform_watcher/models/messages/request/message_post.dart';
import 'package:lifeform_watcher/services/message_service.dart';
import 'package:geolocator/geolocator.dart';

class ObservationPage extends StatefulWidget {
  @override
  State<ObservationPage> createState() => _ObservationPageState();
}

class _ObservationPageState extends State<ObservationPage> {
  Future<bool>? futureObservation;

  bool servicestatus = false;
  bool haspermission = false;
  LocationPermission? permission;
  Position? position;
  MessagePost? request;

  @override
  void initState() {
    checkGps();
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Column(
        children: [
          Text("Observation"),
          (futureObservation == null) ? messagePost() : buildFutureBuilder(),
          (servicestatus == false)
              ? getLocationFromUser()
              : getLocationFromGPS(),
        ],
      ),
    );
  }

  Text getLocationFromUser() => Text("GPS ikke slået til.");

  Text getLocationFromGPS() => Text("GPS er slået til");

  ElevatedButton messagePost() {
    request = MessagePost(
        //display message
        userId: 1,
        eukaryoteId: 1,
        moment: DateTime.now(),
        latitude: 25.1,
        longtitude: 10.1,
        title: "From App",
        text: "This is a test message, please ignore");
    return ElevatedButton(
        onPressed: () {
          setState(() {
            futureObservation = postMessage(request!); //null check
          });
        },
        child: Column(
          children: [
            Icon(Icons.message),
            if (request != null)
              displayMessageData(request!) //write like the msg feed
          ],
        ));
  }

  Row displayMessageData(MessagePost messagePost) {
    print("Test");
    return Row(
      children: [Text(messagePost.title), Text(messagePost.text)],
    );
  }

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

  checkGps() async {
    servicestatus = await Geolocator.isLocationServiceEnabled();
    print(
        servicestatus); //used to check if permission is given, if not user has to set the values themself
    if (servicestatus) {
      permission = await Geolocator.checkPermission();
      print(permission);
      if (permission == LocationPermission.denied) {
        permission = await Geolocator.requestPermission();
        print(permission);
        if (permission == LocationPermission.denied) {
        } else if (permission == LocationPermission.deniedForever) {
        } else {
          haspermission = true;
          //var position = await Geolocator.getCurrentPosition(
          //desiredAccuracy: LocationAccuracy.high);
          //trying to get without permission and the program crashes
          //instead of getting location, set a bool
          //https://www.fluttercampus.com/guide/212/get-gps-location/
        }
      } else {
        haspermission = true;
      }
    }
    setState(() {});
  }

  getPosition() async {
    if (haspermission) {
      position = await Geolocator.getCurrentPosition(
          desiredAccuracy: LocationAccuracy.bestForNavigation);
      setState(() {});
    }
  }
}
