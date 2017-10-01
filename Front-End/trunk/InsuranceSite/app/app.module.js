"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/http");
var app_component_1 = require("./app.component");
var ng2_bs3_modal_1 = require("ng2-bs3-modal/ng2-bs3-modal");
var ngx_pagination_1 = require("ngx-pagination");
var app_routing_1 = require("./app.routing");
var user_component_1 = require("./Components/user.component");
var user_service_1 = require("./Service/user.service");
var policy_component_1 = require("./Components/policy.component");
var policy_service_1 = require("./Service/policy.service");
var user_pipe_1 = require("./Pipes/user.pipe");
var policy_pipe_1 = require("./Pipes/policy.pipe");
var search_component_1 = require("./Components/search.component");
var login_component_1 = require("./Components/login.component");
var auth_guard_1 = require("./Guards/auth.guard");
var auth_service_1 = require("./Service/auth.service");
var message_service_1 = require("./Service/message.service");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            imports: [platform_browser_1.BrowserModule, forms_1.ReactiveFormsModule, http_1.HttpModule, app_routing_1.routing, ngx_pagination_1.NgxPaginationModule, ng2_bs3_modal_1.Ng2Bs3ModalModule, forms_1.FormsModule],
            declarations: [app_component_1.AppComponent, user_component_1.UserComponent, policy_component_1.PolicyComponent, user_pipe_1.UserFilterPipe, policy_pipe_1.PolicyFilterPipe, search_component_1.SearchComponent, login_component_1.LoginComponent],
            providers: [{ provide: common_1.APP_BASE_HREF, useValue: '/' }, user_service_1.UserService, policy_service_1.PolicyService, auth_guard_1.AuthGuard, auth_service_1.AuthService, message_service_1.MessageService],
            bootstrap: [app_component_1.AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map