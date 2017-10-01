import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from '../Service/auth.service';
import { MessageService } from '../Service/message.service';

@Component({
	templateUrl: 'app/Components/login.component.html'
})

export class LoginComponent implements OnInit {
	model: any = {};
	loading = false;
	returnUrl: string;
	msg: string;

	constructor(
		private route: ActivatedRoute,
		private router: Router,
		private authenticationService: AuthService,
		private messageService: MessageService) {
	}

	ngOnInit() {
		// reset login status
		this.messageService.sendMessage(null);
		this.authenticationService.logout();

		// get return url from route parameters or default to '/'
		this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
	}

	login() {
		this.loading = true;
		this.authenticationService.login(this.model.username)
			.subscribe(
			data => {
				this.messageService.sendMessage(JSON.parse(localStorage.getItem('currentUser')).name);
				this.router.navigate([this.returnUrl]);
			},
			error => {
				this.msg = <any>error
				this.loading = false;
			});
	}
}