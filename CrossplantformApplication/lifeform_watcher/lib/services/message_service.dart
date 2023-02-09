import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:lifeform_watcher/models/messages/message_list_item.dart';

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

List<MessageListItem> _parseMessageList(String responseBody) {
  final parsed = jsonDecode(responseBody).cast<Map<String, dynamic>>();
  return parsed
      .map<MessageListItem>((json) => MessageListItem.fromJson(json))
      .toList();
}

MessageDetails _parseMessageDetails(String responseBody) {
  return MessageDetails.fromJson(jsonDecode(responseBody));
}
