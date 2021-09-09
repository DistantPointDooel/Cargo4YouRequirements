import { Component } from '@angular/core';
import { DocumentationService } from '../services/documentation.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor(private documentationService: DocumentationService) {

  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  redirectToDocs() {
    window.open(this.documentationService.redirectToDocs());
  }
}
