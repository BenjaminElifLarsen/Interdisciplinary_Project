class MessageDetails {
  final int likes;
  final int user;
  final int lifeformId;
  final double latitude;
  final double longtitude;
  final String title;
  final String text;
  final DateTime time;

  const MessageDetails({
    required this.likes,
    required this.user,
    required this.lifeformId,
    required this.latitude,
    required this.longtitude,
    required this.title,
    required this.text,
    required this.time,
  });

  factory MessageDetails.fromJson(Map<String, dynamic> json) {
    return MessageDetails(
        likes: json['likes'],
        user: json['user'],
        lifeformId: json['lifeformId'],
        latitude: json['latitude'] + 0.0,
        longtitude: json['longtitude'] + 0.0,
        title: json['title'],
        text: json['text'],
        time: DateTime.parse(json['time']));
  }
}
