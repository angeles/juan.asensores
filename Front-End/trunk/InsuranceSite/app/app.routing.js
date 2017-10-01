"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var router_1 = require("@angular/router");
var user_component_1 = require("./Components/user.component");
var policy_component_1 = require("./Components/policy.component");
var login_component_1 = require("./Components/login.component");
var auth_guard_1 = require("./Guards/auth.guard");
var appRoutes = [
    { path: '', redirectTo: 'user', pathMatch: 'full' },
    { path: 'user', component: user_component_1.UserComponent, canActivate: [auth_guard_1.AuthGuard] },
    { path: 'policy', component: policy_component_1.PolicyComponent, canActivate: [auth_guard_1.AuthGuard] },
    { path: 'auth', component: login_component_1.LoginComponent }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map