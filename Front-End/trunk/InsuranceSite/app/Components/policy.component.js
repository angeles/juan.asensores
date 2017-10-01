"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var policy_service_1 = require("../Service/policy.service");
var user_service_1 = require("../Service/user.service");
var ng2_bs3_modal_1 = require("ng2-bs3-modal/ng2-bs3-modal");
var global_1 = require("../Shared/global");
var PolicyComponent = /** @class */ (function () {
    function PolicyComponent(_policyService, _userService, route) {
        this._policyService = _policyService;
        this._userService = _userService;
        this.route = route;
        this.cantPerPage = 8;
        this.indLoading = false;
        this.clientLoad = false;
        this.p = 1;
        this.searchTitle = "Search: ";
    }
    PolicyComponent.prototype.ngOnInit = function () {
        this._client = {
            id: '',
            name: '',
            email: '',
            role: ''
        };
        this.LoadPolicies();
    };
    Object.defineProperty(PolicyComponent.prototype, "client", {
        set: function (client) {
            this.policies = [];
            this._client = client;
            this.LoadPolicies(client.id);
        },
        enumerable: true,
        configurable: true
    });
    PolicyComponent.prototype.LoadPolicies = function (clientId) {
        var _this = this;
        if (clientId === void 0) { clientId = null; }
        var cond = '';
        this.indLoading = true;
        if (clientId != null && clientId != '') {
            cond = '?clientId=' + clientId;
            this.clientLoad = true;
        }
        else
            this.clientLoad = false;
        this._policyService.get(global_1.Global.BASE_POLICY_ENDPOINT + cond)
            .subscribe(function (policies) {
            _this.policies = policies;
            _this.indLoading = false;
        }, function (error) { return _this.msg = error; });
    };
    PolicyComponent.prototype.viewClient = function (id) {
        var _this = this;
        this._userService.byId(global_1.Global.BASE_USER_ENDPOINT, id)
            .subscribe(function (client) {
            _this._client = client;
            _this.modal.open();
        }, function (error) { return _this.msg = error; });
    };
    PolicyComponent.prototype.criteriaChange = function (value) {
        if (value != '[object Event]')
            this.listFilter = value;
    };
    __decorate([
        core_1.ViewChild('modal'),
        __metadata("design:type", ng2_bs3_modal_1.ModalComponent)
    ], PolicyComponent.prototype, "modal", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Number)
    ], PolicyComponent.prototype, "cantPerPage", void 0);
    __decorate([
        core_1.Input(),
        __metadata("design:type", Object),
        __metadata("design:paramtypes", [Object])
    ], PolicyComponent.prototype, "client", null);
    PolicyComponent = __decorate([
        core_1.Component({
            selector: 'policies',
            templateUrl: 'app/Components/policy.component.html'
        }),
        __metadata("design:paramtypes", [policy_service_1.PolicyService, user_service_1.UserService, router_1.ActivatedRoute])
    ], PolicyComponent);
    return PolicyComponent;
}());
exports.PolicyComponent = PolicyComponent;
//# sourceMappingURL=policy.component.js.map