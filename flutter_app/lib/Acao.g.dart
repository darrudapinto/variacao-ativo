// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'Acao.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Acao _$AcaoFromJson(Map<String, dynamic> json) {
  return Acao(
    (json['historico'] as List<dynamic>)
        .map((e) => Historico.fromJson(e as Map<String, dynamic>))
        .toList(),
  );
}

Map<String, dynamic> _$AcaoToJson(Acao instance) => <String, dynamic>{
      'historico': instance.historico.map((e) => e.toJson()).toList(),
    };
