import { Component } from '@angular/core';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent {
  public reload: boolean = false;
  setReload(): void {
    this.reload = true;
    setTimeout(() => {
      this.reload = false;
    }, 1000);
  }
}
