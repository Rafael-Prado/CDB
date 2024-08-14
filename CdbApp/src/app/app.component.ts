import { Component } from '@angular/core';
import { InvestmentService } from './Service/InvestmentService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppCalculadorComponente {
  title = 'Calculo CDB';

  valorInicial: number = 0;
  mes: number = 0;
  resultado: any;

  constructor(private investmentService: InvestmentService) { }

  onSubmit(): void {
    this.investmentService.calculateInvestment(this.valorInicial, this.mes)
      .subscribe(data => {
        this.resultado = data;
      }, error => {
        console.error('Error no calculo do cdb', error);
      });
  }
}
