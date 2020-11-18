import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Dating App';
  users: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get('https://localhost:44344/api/org?CurrentPage=2&PageSize=5&Column1=ID').subscribe(response => {
      this.users = response;
      console.log(response);
    }, error => {
      console.log(error);
    }, () => {
      console.log('Http Get Completed');
    })
  }
}