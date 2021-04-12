// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'Historico.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Historico _$HistoricoFromJson(Map<String, dynamic> json) {
  return Historico(
    DateTime.parse(json['dataPregao'] as String),
    (json['valorAbertura'] as num).toDouble(),
    (json['variacaoDiaAnterior'] as num).toDouble(),
    (json['variacaoInicioPeriodo'] as num).toDouble(),
  );
}

Map<String, dynamic> _$HistoricoToJson(Historico instance) => <String, dynamic>{
      'dataPregao': instance.dataPregao.toIso8601String(),
      'valorAbertura': instance.valorAbertura,
      'variacaoDiaAnterior': instance.variacaoDiaAnterior,
      'variacaoInicioPeriodo': instance.variacaoInicioPeriodo,
    };
