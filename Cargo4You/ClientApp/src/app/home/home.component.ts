import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CouriersDto } from '../models/couriers-dto.model';
import { CreateParcelChecksDto } from '../models/create-parcel-check-dto.model';
import { CouriersService } from '../services/couriers-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  model: CreateParcelChecksDto = new CreateParcelChecksDto();

  courierPrices: CouriersDto[] = [];

  constructor(private couriersService: CouriersService) {

  }

  ngOnInit(): void {
    
  }

  search(packageForm: NgForm) {
    this.courierPrices = [];

    this.couriersService.searchPrices(this.model)
      .subscribe(result =>
      {
        this.courierPrices = result;
        packageForm.resetForm();
      });
  }
}
