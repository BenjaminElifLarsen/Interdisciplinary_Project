class MessageDetailsAuthor {
  final String username;

  const MessageDetailsAuthor({
    required this.username,
  });

  factory MessageDetailsAuthor.fromJson(Map<String, dynamic> json) {
    return MessageDetailsAuthor(username: json['username']);
  }
}
