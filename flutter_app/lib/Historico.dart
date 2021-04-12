import 'package:json_annotation/json_annotation.dart';
part 'Historico.g.dart';

@JsonSerializable()
class Historico {
  Historico(this.dataPregao, this.valorAbertura, this.variacaoDiaAnterior, this.variacaoInicioPeriodo);

  final DateTime dataPregao;
  final double valorAbertura;
  final double variacaoDiaAnterior;
  final double variacaoInicioPeriodo;

  factory Historico.fromJson(Map<String, dynamic> json) => _$HistoricoFromJson(json);
  Map<String, dynamic> toJson() => _$HistoricoToJson(this);
}