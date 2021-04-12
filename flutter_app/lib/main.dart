import 'LineChart.dart';
import 'package:flutter/material.dart';

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {
  static final String title = 'FL Line Chart';

  @override
  Widget build(BuildContext context) => MaterialApp(
    debugShowCheckedModeBanner: false,
    title: title,
    theme: ThemeData(primaryColor: Colors.blueGrey[900]),
    home: LineChartWidget(),
  );
}





// import 'dart:async';
// import 'dart:convert';
// import 'package:flutter/material.dart';
// import 'package:http/http.dart' as http;
// import 'package:intl/intl.dart';
// import 'Acao.dart';
// import 'Historico.dart';
// import 'package:charts_flutter/flutter.dart' as charts;
//
// Future<Acao> fetchAcao() async {
//   final response =
//   // await http.get(Uri.https('jsonplaceholder.typicode.com', 'albums/1'));
//   await http.get(Uri.http('127.0.0.1:5000', 'acoes/PETR4.SA'));
//
//   if (response.statusCode == 200) {
//     // If the server did return a 200 OK response,
//     // then parse the JSON.
//     return Acao.fromJson(jsonDecode(response.body));
//   } else {
//     // If the server did not return a 200 OK response,
//     // then throw an exception.
//     throw Exception('Failed to load data');
//   }
// }
//
// void main() => runApp(MyApp());
//
// class MyApp extends StatefulWidget {
//   MyApp({Key? key}) : super(key: key);
//
//   @override
//   _MyAppState createState() => _MyAppState();
// }
//
// class _MyAppState extends State<MyApp> {
//   late Future<Acao> acaoHistorico;
//
//   @override
//   void initState() {
//     super.initState();
//     acaoHistorico = fetchAcao();
//   }
//
//   @override
//   Widget build(BuildContext context) {
//     return MaterialApp(
//       title: 'Variação Ação',
//       theme: ThemeData(
//         primarySwatch: Colors.blue,
//       ),
//       home: Scaffold(
//         appBar: AppBar(
//           title: Text('Variação Ação'),
//         ),
//         body: Center(
//           child: FutureBuilder<Acao>(
//             future: acaoHistorico,
//             builder: (context, snapshot) {
//               if (snapshot.hasData) {
//                 // return Text("Valor Abertura: ${snapshot.data!.historico.first.valorAbertura}");
//                 return ListView.builder(
//                   itemCount: snapshot.data!.historico.length,
//                   itemBuilder: (context, index) {
//                     Historico historico = snapshot.data!.historico[index];
//                     final dateFormatter = new DateFormat('dd/MM/yyyy');
//                     return Column(
//                       children: <Widget>[
//                         ListTile(
//                           leading: Icon(Icons.bar_chart),
//                           title: Text('Data: ${dateFormatter.format(historico.dataPregao)}'),
//                           subtitle: Text('Abertura: R\$ ${historico.valorAbertura.toString()} \nVariacao (D-1): ${historico.variacaoDiaAnterior.toString()} %\nVariação início: ${historico.variacaoInicioPeriodo.toString()} %'),
//                           dense: true
//                         ),
//                       ]
//                     );
//                   },
//                 );
//               } else if (snapshot.hasError) {
//                 return Text("${snapshot.error}");
//               }
//
//               // By default, show a loading spinner.
//               return CircularProgressIndicator();
//             },
//           ),
//         ),
//       ),
//     );
//   }
// }