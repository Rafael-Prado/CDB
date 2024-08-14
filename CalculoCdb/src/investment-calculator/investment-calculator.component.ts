import { Component } from '@angular/core';
import { InvestmentService } from '../services/investment.service';
import { InvestimentoRequest } from '../models/investimento-request'; 
import { InvestimentoResponse } from '../models/investimento-response'; 

@Component({
  selector: 'app-investment-calculator',
  templateUrl: './investment-calculator.component.html',
  styleUrls: ['./investment-calculator.component.css']
})
export class InvestmentCalculatorComponent {
  investimentoRequest: InvestimentoRequest = { Valor: 0, Mes: 0 };
  result: any;
  constructor(private investmentService: InvestmentService) {
    
  }

  onSubmit(): void {
    this.investmentService.calculateInvestment(this.investimentoRequest)
      .subscribe(data => {
        this.result = data;
        console.log(this.result);
      }, error => {
        console.error('Error calculating investment', error);
      });
  }
}
