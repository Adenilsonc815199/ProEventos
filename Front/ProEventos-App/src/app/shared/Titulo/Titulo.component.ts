import { Component,Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-Titulo',
  templateUrl: './Titulo.component.html',
  styleUrls: ['./Titulo.component.scss']
})
export class TituloComponent implements OnInit {
  @Input() Titulo: string = 'Eventos';
  constructor() { }

  ngOnInit() {
  }

}
