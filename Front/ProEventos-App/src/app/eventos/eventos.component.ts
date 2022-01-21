import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})

export class EventosComponent implements OnInit {
  public eventos: any = [];
  public eventosFiltrados :any = [];
  LarguraImagem: Number = 150;
  MargemImagem: Number = 2;
  ExibirImagem: boolean = true;
  private _filtroLista: string = '';

  public get filtroLista(): string{
    return this._filtroLista;
  }
  //Recebe o filtroLista, chama o FiltrarEventos e atribui os resultados em eventosFiltrados
  public set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }
 //Compara o filtroLista e compara com o atributo tema do evento e retorna só os filtrados
  filtrarEventos(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();
   //Filtra por tema ou por local do evento
    return this.eventos.filter(
    (evento:any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
    evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

//Get que chama os eventos da API e importa o componente HttpClient para operações REST
public getEventos(): void{
  this.http.get('https://localhost:5001/api/eventos').subscribe(
    response => {
      this.eventos = response;
      this.eventosFiltrados = this.eventos;
    },
    error => console.log(error)
  );
}
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }
  alterarImagem(){
    this.ExibirImagem = !this.ExibirImagem;
  }

}
