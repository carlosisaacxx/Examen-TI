import { Component } from '@angular/core';
import { UsersService } from '../../../core/service/users.service';
import { CreateUser } from '../../../core/models/users.interface';
import { ModalsComponent } from '../../../shared/components/modals/modals.component';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ModalsComponent],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  constructor(private userService: UsersService){}
  createUser(){
    const newUser: CreateUser = {
      Email: 'testangular@example.com',
      Password: 'password123',
      Role: 'admin'
    };

    this.userService.CreateUser(newUser).subscribe(
      (response) => {
        debugger;
        console.log('User created successfully', response);
      },
      (error) => {
        debugger;
        console.error('Error creating user', error);
      }
    );
  }
}
