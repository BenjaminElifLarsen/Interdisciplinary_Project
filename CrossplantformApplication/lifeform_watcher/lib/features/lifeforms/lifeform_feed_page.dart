import 'package:flutter/material.dart';
import 'package:lifeform_watcher/models/lifeforms/lifeform_list_item.dart';
import 'package:lifeform_watcher/services/lifeform_service.dart';

class LifeformFeedPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Center(
      child: ListView(
        children: [
          Row(mainAxisAlignment: MainAxisAlignment.center, children: [
            Column(
              children: [
                Padding(
                  padding: const EdgeInsets.all(8.0),
                  child: AnimalFeed(),
                ),
              ],
            ),
            Column(
              children: [
                Padding(
                  padding: const EdgeInsets.all(8.0),
                  child: PlantFeed(),
                )
              ],
            ),
          ]),
        ],
      ),
    );
  }
}

class PlantFeed extends StatelessWidget {
  const PlantFeed({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text("Plante"),
        FutureBuilder<List<LifeformListItem>>(
            future: fetchPlants(),
            builder: (context, snapshot) {
              if (snapshot.hasError) {
                return const Center(
                  child: Text("Error"),
                );
              } else if (snapshot.hasData) {
                return PlantList(list: snapshot.data!);
              } else {
                return const Center(
                  child: CircularProgressIndicator(),
                );
              }
            })
      ],
    );
  }
}

class PlantList extends StatelessWidget {
  const PlantList({
    super.key,
    required this.list,
  });
  final List<LifeformListItem> list;
  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        for (var plant in list) Text(plant.species),
      ],
    );
  }
}

class AnimalFeed extends StatelessWidget {
  const AnimalFeed({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text("Dyr"),
        FutureBuilder<List<LifeformListItem>>(
            future: fetchAnimals(),
            builder: (context, snapshot) {
              if (snapshot.hasError) {
                return const Center(
                  child: Text("Error"),
                );
              } else if (snapshot.hasData) {
                return AnimalList(list: snapshot.data!);
              } else {
                return const Center(
                  child: CircularProgressIndicator(),
                );
              }
            })
      ],
    );
  }
}

class AnimalList extends StatelessWidget {
  const AnimalList({
    super.key,
    required this.list,
  });
  final List<LifeformListItem> list;
  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        for (var animal in list) Text(animal.species),
      ],
    );
  }
}
