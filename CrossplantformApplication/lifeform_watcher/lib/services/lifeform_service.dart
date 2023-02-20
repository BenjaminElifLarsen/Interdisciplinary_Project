import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:lifeform_watcher/models/lifeforms/animal_details.dart';

import 'package:lifeform_watcher/models/lifeforms/lifeform_list_item.dart';
import 'package:lifeform_watcher/models/lifeforms/plant_details.dart';
import 'package:lifeform_watcher/models/lifeforms/request/animal_post.dart';
import 'package:lifeform_watcher/models/lifeforms/request/plant_post.dart';

Future<bool> postPlant(PlantPost request) async {
  final response = await http.post(
    Uri.parse('https://localhost:7107/Lifeform/Plant'),
    headers: <String, String>{
      'Content-Type': 'application/json; charset=UTF-8',
    },
    body: jsonEncode(<String, String>{
      'species': request.species,
      'possibleMaximumHeight': request.possibleMaximumHeight.toString(),
    }),
  );
  if (response.statusCode == 201 || response.statusCode == 200) {
    return true;
  } else {
    print(response.body);
    return false;
  }
}

Future<bool> postAnimal(AnimalPost request) async {
  final response = await http.post(
    Uri.parse('https://localhost:7107/Lifeform/Animal'),
    headers: <String, String>{
      'Content-Type': 'application/json; charset=UTF-8',
    },
    body: jsonEncode(<String, String>{
      'species': request.species,
      'isBird': request.isBird.toString(),
      'maxAmountOfOffspring': request.maxAmountOfOffspring.toString(),
      'minAmountOfOffspring': request.minAmountOfOffspring.toString(),
    }),
  );
  if (response.statusCode == 201 || response.statusCode == 200) {
    return true;
  } else {
    print(response.body);
    return false;
  }
}

Future<List<LifeformListItem>> fetchPlants() async {
  final response =
      await http.get(Uri.parse('https://localhost:7107/Lifeform/AllPlants'));
  return _parseLifeformDetails(response.body);
}

Future<List<LifeformListItem>> fetchAnimals() async {
  final response =
      await http.get(Uri.parse('https://localhost:7107/Lifeform/AllAnimals'));
  return _parseLifeformDetails(response.body);
}

Future<AnimalDetails> fetchAnimal(int id) async {
  final response = await http
      .get(Uri.parse("https://localhost:7107/Lifeform/GetAnimal?id=$id"));
  return _parseAnimalDetails(response.body);
}

Future<PlantDetails> fetchPlant(int id) async {
  final response = await http
      .get(Uri.parse("https://localhost:7107/Lifeform/GetPlant?id=$id"));
  return _parsePlantDetails(response.body);
}

List<LifeformListItem> _parseLifeformDetails(String responseBody) {
  final parsed = jsonDecode(responseBody).cast<Map<String, dynamic>>();
  return parsed
      .map<LifeformListItem>((json) => LifeformListItem.fromJson(json))
      .toList();
}

AnimalDetails _parseAnimalDetails(String responseBody) {
  return AnimalDetails.fromJson(jsonDecode(responseBody));
}

PlantDetails _parsePlantDetails(String responseBody) {
  return PlantDetails.fromJson(jsonDecode(responseBody));
}
