class LifeformDetails {
  final String species;
  final int id;

  const LifeformDetails({
    required this.species,
    required this.id,
  });

  factory LifeformDetails.fromJson(Map<String, dynamic> json) {
    return LifeformDetails(species: json['species'], id: json['id']);
  }
}
