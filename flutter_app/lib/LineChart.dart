import 'dart:convert';
import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:intl/intl.dart';
import 'Acao.dart';
import 'Historico.dart';

class LineChartWidget extends StatelessWidget {

  Future<Acao> fetchAcao() async {
    final response = await http.get(Uri.http('127.0.0.1:5000', 'acoes/PETR4.SA'));

    if (response.statusCode == 200) {
      // If the server did return a 200 OK response,
      // then parse the JSON.
      var resposta = Acao.fromJson(jsonDecode(response.body));

      resposta.historico.forEach((element) {
        dadosEixoX.add(FlSpot(element.dataPregao.day.toDouble(), element.variacaoDiaAnterior));
        dadosEixoY.add(FlSpot(element.dataPregao.day.toDouble(), element.variacaoInicioPeriodo));
      });
      return resposta;
    } else {
      // If the server did not return a 200 OK response,
      // then throw an exception.
      throw Exception('Failed to load data');
    }
  }

  late Future<Acao> acaoHistorico = fetchAcao();

  final List<FlSpot> dadosEixoX = [];
  final List<FlSpot> dadosEixoY = [];

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Variação Ação',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: Scaffold(
        appBar: AppBar(
          title: Text('Variação Ação'),
        ),
        body: Center(
          child: FutureBuilder<Acao>(
            future: acaoHistorico,
            builder: (context, snapshot) {
              if (snapshot.hasData) {
                return LineChart(
                  LineChartData(
                    minX: 0,
                    maxX: 30,
                    minY: 0,
                    maxY: 10,
                    // titlesData: LineTitles.getTitleData(),
                    gridData: FlGridData(
                      show: true,
                      getDrawingHorizontalLine: (value) {
                        return FlLine(
                          color: const Color(0xff37434d),
                          strokeWidth: 1,
                        );
                      },
                      drawVerticalLine: true,
                      getDrawingVerticalLine: (value) {
                        return FlLine(
                          color: const Color(0xff37434d),
                          strokeWidth: 1,
                        );
                      },
                    ),
                    borderData: FlBorderData(
                      show: true,
                      border: Border.all(color: const Color(0xff37434d), width: 1),
                    ),
                    lineBarsData: [
                      LineChartBarData(
                        spots: dadosEixoX,
                        isCurved: true,
                        barWidth: 2,
                        colors: [
                          Colors.red,
                        ],
                      ),
                      LineChartBarData(
                        spots: dadosEixoY,
                        isCurved: true,
                        barWidth: 2,
                        colors: [
                          Colors.orange,
                        ],
                      ),
                    ],
                  ),
                );
              } else if (snapshot.hasError) {
                return Text("${snapshot.error}");
              }

              // By default, show a loading spinner.
              return CircularProgressIndicator();
            },
          ),
        ),
      ),
    );
  }
}