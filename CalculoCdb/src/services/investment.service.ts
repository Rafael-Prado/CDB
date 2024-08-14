import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { InvestimentoResponse } from '../models/investimento-response'
import { InvestimentoRequest } from '../models/investimento-request'

@Injectable({
  providedIn: 'root'
})
export class InvestmentService {

  private apiUrl = 'http://localhost:5181/api/CalculoCdb/calcular';

  constructor(private http: HttpClient) { }

  calculateInvestment(request: InvestimentoRequest): Observable<InvestimentoResponse> {
    return this.http.post<InvestimentoResponse>(this.apiUrl, request);
  }
}

