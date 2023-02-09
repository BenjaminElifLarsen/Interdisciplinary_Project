class MessageListItem {
  final int id;
  final int lifeformId;
  final String title;
  final String text;

  const MessageListItem({
    required this.id,
    required this.lifeformId,
    required this.title,
    required this.text,
  });

  factory MessageListItem.fromJson(Map<String, dynamic> json) {
    return MessageListItem(
        id: json['id'],
        lifeformId: json['lifeformId'],
        title: json['title'],
        text: json['text']);
  }
}
