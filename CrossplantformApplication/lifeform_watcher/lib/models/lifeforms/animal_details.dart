class AnimalDetails {
  final String species;
  final bool isBird;
  final int maximumOffspring;
  final int minimumOffspring;
  final List<int> messageIds;

  const AnimalDetails(
      {required this.species,
      required this.isBird,
      required this.maximumOffspring,
      required this.minimumOffspring,
      required this.messageIds});

  factory AnimalDetails.fromJson(Map<String, dynamic> json) {
    return AnimalDetails(
        species: json['species'],
        isBird: json['isBird'],
        maximumOffspring: json['maximumOffspring'],
        minimumOffspring: json['minimumOffspring'],
        messageIds: json['messageIds']);
  }
}
