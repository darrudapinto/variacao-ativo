import 'Historico.dart';
import 'package:json_annotation/json_annotation.dart';
part 'Acao.g.dart';

@JsonSerializable(explicitToJson: true)
class Acao {
  Acao(this.historico);

  final List<Historico> historico;

  factory Acao.fromJson(Map<String, dynamic> json) => _$AcaoFromJson(json);
  Map<String, dynamic> toJson() => _$AcaoToJson(this);
}