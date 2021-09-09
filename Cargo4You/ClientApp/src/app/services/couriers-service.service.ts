import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { CouriersDto } from "../models/couriers-dto.model";
import { CreateParcelChecksDto } from "../models/create-parcel-check-dto.model";

@Injectable()
export class CouriersService {

  private baseUrl: string

  constructor(private httpClient: HttpClient,@Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  
  public searchPrices(model: CreateParcelChecksDto) {
    return this.httpClient.post<CouriersDto[]>(this.baseUrl + "Courier/SearchForPrices", model);
  }

}
