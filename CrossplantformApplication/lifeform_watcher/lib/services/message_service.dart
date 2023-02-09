import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:lifeform_watcher/models/messages/message_list_item.dart';

Future<List<MessageListItem>> fetchMessages() async {
  final response = await http.get(Uri.parse("https://localhost:7107/Message"));
  return _parseMessageList(response.body);
}

List<MessageListItem> _parseMessageList(String responseBody) {
  final parsed = jsonDecode(responseBody).cast<Map<String, dynamic>>();
  print(parsed);
  return parsed
      .map<MessageListItem>((json) => MessageListItem.fromJson(json))
      .toList();
}
