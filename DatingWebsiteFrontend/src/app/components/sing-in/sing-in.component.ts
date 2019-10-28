import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sing-in',
  templateUrl: './sing-in.component.html',
  styleUrls: ['./sing-in.component.css']
})
export class SingInComponent implements OnInit {

  model: any = {};

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  logIn() {
    this.authService.logIn(this.model).subscribe((data) => {
      console.log("zalogowany");
      this.router.navigate(['/home']);
    }, error => {
      console.log('Nieudane logowanie')
    }
    );
  }

}
