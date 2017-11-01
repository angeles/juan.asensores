import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DecimalPipe, CurrencyPipe } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { PolicyService } from '../Service/policy.service';
import { UserService } from '../Service/user.service';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { PaginationControlsComponent } from 'ngx-pagination';
import { IPolicy } from '../Models/policy';
import { IUser } from '../Models/user';
import { Observable } from 'rxjs/Rx';
import { Global } from '../Shared/global';

@Component({
	selector: 'policies',
	templateUrl: 'app/Components/policy.component.html'
})

export class PolicyComponent implements OnInit {
	@ViewChild('modal') modal: ModalComponent;
	@Input() cantPerPage: number = 8;
	policies: IPolicy[];
	_client: IUser;
	msg: string;
	indLoading: boolean = false;
	clientLoad: boolean = false;
	p: number = 1;
	listFilter: string;
	searchTitle: string = "Search: ";

	constructor(private _policyService: PolicyService, private _userService: UserService, private route: ActivatedRoute) { }

	ngOnInit(): void {
		this._client = <any>{
			id: '',
			name: '',
			email: '',
			role: ''
		};

		this.LoadPolicies();
	}

	@Input()
	set client(client: IUser) {
		this.policies = [];
		this._client = client;
		this.LoadPolicies(client.id);
	}

	private LoadPolicies(clientId: AAGUID = null): void {
		var cond = ''
		this.indLoading = true;
		if (clientId != null && clientId != '') {
			cond = '?clientId=' + clientId;
			this.clientLoad = true;
		}
		else
			this.clientLoad = false;

		this._policyService.get(Global.BASE_POLICY_ENDPOINT + cond)
			.subscribe(policies => {
				this.policies = policies;
				this.indLoading = false;
			},
			error => this.msg = <any>error);
	}

	viewClient(id: AAGUID): void {
		this._userService.byId(Global.BASE_USER_ENDPOINT, id)
			.subscribe(client => {
				this._client = client;
				this.modal.open();
			}, error => this.msg = <any>error);
	}

	criteriaChange(value: string): void {
		if (value != '[object Event]')
			this.listFilter = value;
	}
}