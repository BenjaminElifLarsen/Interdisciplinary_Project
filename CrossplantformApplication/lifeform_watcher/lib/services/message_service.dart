import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:lifeform_watcher/models/messages/message_list_item.dart';
import 'package:lifeform_watcher/models/messages/request/message_post.dart';

import '../models/messages/message_details.dart';

Future<List<MessageListItem>> fetchMessages() async {
  final response = await http.get(Uri.parse("https://localhost:7107/Message"));
  return _parseMessageList(response.body);
}

Future<MessageDetails> fetchMessage(int id) async {
  final response = await http.get((Uri.parse(
      "https://localhost:7107/Message/Details?id=$id"))); //catch the cases the body is empty
  print(response);
  return _parseMessageDetails(response.body);
}

Future<bool> postMessage(MessagePost request) async {
  final response = await http.post(
    Uri.parse("https://localhost:7107/Message"),
    headers: <String, String>{
      'Content-Type': 'application/json; charset=UTF-8',
    },
    body: jsonEncode(<String, String>{
      'moment': request.moment.toIso8601String(),
      'text': request.text,
      'title': request.title,
      'eukaryoteId': request.eukaryoteId.toString(),
      'userId': request.userId.toString(),
      'latitude': request.latitude.toString(),
      'longtitude': request.longtitude.toString(),
    }),
  );
  if (response.statusCode == 201 || response.statusCode == 200) {
    return true;
  } else {
    print(response.body);
    return false;
  }
}

List<MessageListItem> _parseMessageList(String responseBody) {
  final parsed = jsonDecode(responseBody).cast<Map<String, dynamic>>();
  return parsed
      .map<MessageListItem>((json) => MessageListItem.fromJson(json))
      .toList();
}

MessageDetails _parseMessageDetails(String responseBody) {
  return MessageDetails.fromJson(jsonDecode(responseBody));
}
