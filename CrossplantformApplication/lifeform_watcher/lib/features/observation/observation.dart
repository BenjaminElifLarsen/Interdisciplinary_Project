import 'package:flutter/material.dart';
import 'package:lifeform_watcher/models/lifeforms/lifeform_details.dart';
import 'package:lifeform_watcher/models/messages/request/message_post.dart';
import 'package:lifeform_watcher/services/lifeform_service.dart';
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
  late ThemeData theme;
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  String title = "";
  String text = "";
  double latitude = 0;
  double longtitude = 0;
  int lifeformId = 0;

  @override
  void initState() {
    checkGps();
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    theme = Theme.of(context);
    return Center(
      child: Column(
        children: [
          Text("Observation"),
          MessageForm(),
          (futureObservation == null) ? messagePost() : buildFutureBuilder(),
          (servicestatus == false)
              ? getLocationFromUser()
              : getLocationFromGPS(),
          //if (request != null)
          //displayMessageData(request!), //move this out of the button
          LifeformList()
        ],
      ),
    );
  }

  Form MessageForm() {
    // https://api.flutter.dev/flutter/widgets/Form-class.html
    return Form(
      key: _formKey,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          TextFormField(
            onSaved: (value) {
              title = value!;
            },
            decoration: const InputDecoration(
              hintText: "Enter Title",
            ),
            validator: (String? value) {
              if (value == null || value.isEmpty) {
                return 'Please enter valid title';
              }

              return null;
            },
          ),
          TextFormField(
            onSaved: (value) {
              text = value!;
            },
            decoration: const InputDecoration(
              hintText: "Enter Text",
            ),
            validator: (String? value) {
              if (value == null || value.isEmpty) {
                return 'Please enter valid text';
              }

              return null;
            },
          ),
          TextFormField(
            onSaved: (value) {
              lifeformId = int.parse(value!);
            },
            decoration: const InputDecoration(
              hintText: "Enter LifeformId",
            ),
            validator: (String? value) {
              if (value == null || value.isEmpty) {
                //figure out how to try parse to double
                return 'Please enter a valid number';
              }

              var valCasted = int.tryParse(value!);
              if (valCasted == null) {
                return 'Please enter a valid number';
              }
              return null;
            },
          ),
          ElevatedButton(
            onPressed: () {
              if (_formKey.currentState!.validate()) {
                _formKey.currentState!.save();
                setState(() {});
              }
            },
            child: Text("Ready"),
          )
        ],
      ),
    );
  }

  Text getLocationFromUser() => Text(
      "GPS ikke slået til."); //have a form to enter longtitude and latitude, which user knows their location

  Text getLocationFromGPS() {
    return Text("GPS er slået til");
  }

  ElevatedButton messagePost() {
    request = MessagePost(
        //display message
        userId: 1,
        eukaryoteId: lifeformId,
        moment: DateTime.now(),
        latitude: latitude,
        longtitude: longtitude,
        title: title,
        text: text);
    return ElevatedButton(
        onPressed: () {
          setState(() {
            futureObservation = postMessage(request!); //null check
          });
        },
        child: Column(
          children: [
            Icon(Icons.message),
          ],
        ));
  }

  Row displayMessageData(MessagePost messagePost) {
    print("Test");
    return Row(
      children: [displayText(messagePost.title), displayText(messagePost.text)],
    );
  }

  FutureBuilder<bool> buildFutureBuilder() {
    return FutureBuilder<bool>(
        future: futureObservation,
        builder: (context, snapshot) {
          if (snapshot.hasError) {
            print(snapshot.error);
            return displayText("Errored");
          } else if (snapshot.hasData) {
            return displayText("Posted");
          } else {
            return const CircularProgressIndicator();
          }
        });
  }

  Card displayText(String text) => Card(
          child: Padding(
        padding: const EdgeInsets.all(10),
        child: Text(text),
      ));

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
          getPosition();
          haspermission = true;
          //https://www.fluttercampus.com/guide/212/get-gps-location/
        }
      } else {
        haspermission = true;
        getPosition();
      }
    }
    setState(() {});
  }

  getPosition() async {
    if (haspermission) {
      position = await Geolocator.getCurrentPosition(
          desiredAccuracy: LocationAccuracy.bestForNavigation);
      latitude = position!.latitude;
      longtitude = position!.longitude;
      print(position);
    }
  }
}

class LifeformList extends StatelessWidget {
  const LifeformList({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text("Livsformer"),
        FutureBuilder<List<LifeformDetails>>(
          future: fetchAll(),
          builder: (context, snapshot) {
            if (snapshot.hasError) {
              return const Center(
                child: Text("Error"),
              );
            } else if (snapshot.hasData) {
              return LifeformInfo(list: snapshot.data!);
            } else {
              return const Center(
                child: CircularProgressIndicator(),
              );
            }
          },
        )
      ],
    );
  }
}

class LifeformInfo extends StatelessWidget {
  const LifeformInfo({super.key, required this.list});
  final List<LifeformDetails> list;

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [for (var lifeform in list) Details(info: lifeform)],
    );
  }
}

class Details extends StatelessWidget {
  const Details({super.key, required this.info});

  final LifeformDetails info;
  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [Text(info.id.toString()), Text(info.species)],
    );
  }
}
