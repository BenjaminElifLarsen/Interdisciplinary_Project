import 'dart:ffi';

import 'package:flutter/material.dart';
import 'package:lifeform_watcher/models/lifeforms/request/plant_post.dart';
import 'package:lifeform_watcher/services/lifeform_service.dart';

class RecognisePlantPage extends StatefulWidget {
  @override
  State<RecognisePlantPage> createState() => _RecognisePlantPageState();
}

class _RecognisePlantPageState extends State<RecognisePlantPage> {
  Future<bool>? futurePost;

  String species = "";
  double maximumHeight = 0;

  bool canPost = false;
  PlantPost? request;

  final GlobalKey<FormState> _formkey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Column(children: [
        Text('Recognise Plant'),
        postForm(),
        (futurePost == null) ? post() : buildFutureBuilder()
      ]),
    );
  }

  Form postForm() {
    return Form(
      key: _formkey,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          TextFormField(
            onSaved: (value) {
              species = value!;
            },
            decoration: const InputDecoration(
              hintText: 'Enter Species',
            ),
            validator: (String? value) {
              if (value == null || value.isEmpty)
                return 'Pleae enter valid species';
              return null;
            },
          ),
          TextFormField(
            onSaved: (value) {
              maximumHeight = double.parse(value!);
            },
            decoration: const InputDecoration(
                hintText: 'Enter possible maximum height'),
            validator: (String? value) {
              if (value == null || value.isEmpty) {
                //figure out how to try parse to double
                return 'Please enter a valid number';
              }

              var valCasted = double.tryParse(value!);
              if (valCasted == null) {
                return 'Please enter a valid number';
              } else if (valCasted <= 0) {
                return 'Please enter a valid number';
              }
              return null;
            },
          ),
          ElevatedButton(
            onPressed: () {
              if (_formkey.currentState!.validate()) {
                _formkey.currentState!.save();
                setState(() {
                  canPost = true;
                });
              }
            },
            child: Text("Ready"),
          )
        ],
      ),
    );
  }

  ElevatedButton post() {
    request = PlantPost(species: species, possibleMaximumHeight: maximumHeight);
    return ElevatedButton(
        onPressed: () {
          print(request!.species);
          print(request!.possibleMaximumHeight);
          setState(() {
            if (canPost) {
              futurePost = postPlant(request!);
            }
          });
        },
        child: Icon(Icons.message));
  }

  Card displayText(String text) => Card(
          child: Padding(
        padding: const EdgeInsets.all(10),
        child: Text(text),
      ));

  FutureBuilder<bool> buildFutureBuilder() {
    return FutureBuilder<bool>(
        future: futurePost,
        builder: (context, snapshot) {
          if (snapshot.hasError) {
            print(snapshot.error);
            setState(() {
              futurePost = null;
            });
            return Text("Errored");
          } else if (snapshot.hasData) {
            return displayText("Posted");
          } else {
            return const CircularProgressIndicator();
          }
        });
  }
}
