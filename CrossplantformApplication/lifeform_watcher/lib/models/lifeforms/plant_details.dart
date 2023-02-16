class PlantDetails {
  final String species;
  final double maximumPossibleHeight;
  final List<int> messageIds;

  const PlantDetails(
      {required this.species,
      required this.maximumPossibleHeight,
      required this.messageIds});

  factory PlantDetails.fromJson(Map<String, dynamic> json) {
    return PlantDetails(
        species: json['species'],
        maximumPossibleHeight: json['maximumPossibleHeight'],
        messageIds: json['messageIds']);
  }
}
