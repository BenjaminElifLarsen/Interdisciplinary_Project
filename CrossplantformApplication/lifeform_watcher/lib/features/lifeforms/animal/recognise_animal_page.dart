import 'package:flutter/material.dart';
import 'package:lifeform_watcher/models/lifeforms/request/animal_post.dart';
import 'package:lifeform_watcher/services/lifeform_service.dart';

class RecogniseAnimalPage extends StatefulWidget {
  @override
  State<RecogniseAnimalPage> createState() => _RecogniseAnimalPageState();
}

class _RecogniseAnimalPageState extends State<RecogniseAnimalPage> {
  Future<bool>? futurePost;

  String species = "";
  int maxOffspring = 0;
  int minOffspring = 0;
  bool isBird = false;

  bool canPost = false;

  AnimalPost? request;

  final GlobalKey<FormState> _formkey = GlobalKey<FormState>();
  @override
  Widget build(BuildContext context) {
    return Center(
      child: Column(children: [
        Text('Recognise Animal'),
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
              maxOffspring = int.parse(value!);
            },
            decoration:
                const InputDecoration(hintText: 'Enter maximum offspring'),
            validator: (value) {
              if (value == null || value.isEmpty) {
                return 'Please enter a valid number';
              }
              var valCasted = int.tryParse(value!);
              if (valCasted == null) {
                return 'Please enter a valid number';
              } else if (valCasted <= 0 || valCasted > 255) {
                return 'Please enter a valid number';
              }
              return null;
            },
          ),
          TextFormField(
            onSaved: (value) {
              minOffspring = int.parse(value!);
            },
            decoration:
                const InputDecoration(hintText: 'Enter minimum offspring'),
            validator: (value) {
              if (value == null || value.isEmpty) {
                return 'Please enter a valid number';
              }
              var valCasted = int.tryParse(value!);
              if (valCasted == null) {
                return 'Please enter a valid number';
              } else if (valCasted <= 0 || valCasted > 255) {
                return 'Please enter a valid number';
              }
              return null;
            },
          ),
          TextFormField(
            onSaved: (value) {},
            decoration:
                const InputDecoration(hintText: 'Enter true or false for bird'),
            validator: (value) {
              if (value == null || value.isEmpty) {
                return 'Please enter a valid number';
              }
              if (value.toLowerCase() == 'true') {
                isBird = true;
              } else if (value.toLowerCase() == 'false') {
                isBird = false;
              } else {
                return 'Enter either true or false';
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

  Card displayText(String text) => Card(
          child: Padding(
        padding: const EdgeInsets.all(10),
        child: Text(text),
      ));

  ElevatedButton post() {
    request = AnimalPost(
        species: species,
        isBird: isBird,
        maxAmountOfOffspring: maxOffspring,
        minAmountOfOffspring: minOffspring);
    return ElevatedButton(
        onPressed: () {
          print(request!.species);
          setState(() {
            if (canPost) {
              futurePost = postAnimal(request!);
            }
          });
        },
        child: Icon(Icons.message));
  }

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
