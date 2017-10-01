import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../Service/user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { PaginationControlsComponent } from 'ngx-pagination';
import { IUser } from '../Models/user';
import { Observable } from 'rxjs/Rx';
import { Global } from '../Shared/global';

@Component({
	templateUrl: 'app/Components/user.component.html'
})

export class UserComponent implements OnInit {
	@ViewChild('modal') modal: ModalComponent;
	users: IUser[];
	user: IUser;
	msg: string;
	indLoading: boolean = false;
	x: number = 1;
	listFilter: string;
	searchTitle: string = "Search: ";

	constructor(private _userService: UserService) { }

	ngOnInit(): void {
		this.user = <any>{
			id: '',
			name: '',
			email: '',
			role: ''
		};

		this.LoadUsers();
	}

	private LoadUsers(): void {
		this.indLoading = true;
		this._userService.get(Global.BASE_USER_ENDPOINT)
			.subscribe(users => { this.users = users; this.indLoading = false; },
			error => this.msg = <any>error);
	}

	viewDetail(id: AAGUID): void {
		this.user = this.users.filter(x => x.id == id)[0];
		this.modal.open();
	}

	criteriaChange(value: string): void {
		if (value != '[object Event]')
			this.listFilter = value;
	}
}