class MessagePost {
  final int userId;
  final int eukaryoteId;
  final DateTime moment;
  final double latitude;
  final double longtitude;
  final String title;
  final String text;

  const MessagePost(
      {required this.userId,
      required this.eukaryoteId,
      required this.moment,
      required this.latitude,
      required this.longtitude,
      required this.title,
      required this.text});

  toJson() {
    return {
      userId: "$userId",
      eukaryoteId: "$eukaryoteId",
      moment: "$moment",
      latitude: "$latitude",
      longtitude: "$longtitude",
      title: "$title",
      text: "$text"
    };
  }
}
