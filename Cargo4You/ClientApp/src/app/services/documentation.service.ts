import { Injectable } from "@angular/core";

@Injectable()
export class DocumentationService {

  public redirectToDocs() {
    return "https://localhost:44397/swagger/index.html";
  }
}
