class LifeformListItem {
  final int id;
  final String species;

  const LifeformListItem({required this.id, required this.species});

  factory LifeformListItem.fromJson(Map<String, dynamic> json) {
    return LifeformListItem(id: json['id'], species: json['species']);
  }
}
