import React, { ReactElement, Suspense, lazy } from "react";
import { Router, Route, Switch, Redirect } from "react-router-dom";
import GlobalSpinner from "../components/globalSpinner";
import NagistarLoading from "../components/nagistarLoading";
import history from "../utils/history";
var delayTime = 500;
const Home = lazy(() => {
    return Promise.all([
        import("../views/home"),
        new Promise(resolve => setTimeout(resolve, delayTime))
    ])
        .then(([moduleExports]) => moduleExports);
});


 

const Dashboard = lazy(() => {
    return Promise.all([
        import("../views/dashboard"),
        new Promise(resolve => setTimeout(resolve, delayTime))
    ])
        .then(([moduleExports]) => moduleExports);
});
 
const Messages = lazy(() => {
    return Promise.all([
        import("../views/messages"),
        new Promise(resolve => setTimeout(resolve, delayTime))
    ])
        .then(([moduleExports]) => moduleExports);
});

const Notification = lazy(() => {
    return Promise.all([
        import("../views/notification"),
        new Promise(resolve => setTimeout(resolve, delayTime))
    ])
        .then(([moduleExports]) => moduleExports);
});

const Profile = lazy(() => {
    return Promise.all([
        import("../views/profile"),
        new Promise(resolve => setTimeout(resolve, delayTime))
    ])
        .then(([moduleExports]) => moduleExports);
});

const YourProperty = lazy(() => {
    return Promise.all([
        import("../views/yourProperty"),
        new Promise(resolve => setTimeout(resolve, delayTime))
    ])
        .then(([moduleExports]) => moduleExports);
});

const Login = lazy(() => {
    return Promise.all([
        import("../views/login"),
        new Promise(resolve => setTimeout(resolve, delayTime))
    ])
        .then(([moduleExports]) => moduleExports);
});

const Register = lazy(() => {
    return Promise.all([
        import("../views/register"),
        new Promise(resolve => setTimeout(resolve, delayTime))
    ])
        .then(([moduleExports]) => moduleExports);
});

const ForgotPassword = lazy(() => {
    return Promise.all([
        import("../views/forgotPassword"),
        new Promise(resolve => setTimeout(resolve, delayTime))
    ])
        .then(([moduleExports]) => moduleExports);
});
const ResetPassword = lazy(() => {
    return Promise.all([
        import("../views/resetPassword"),
        new Promise(resolve => setTimeout(resolve, delayTime))
    ])
        .then(([moduleExports]) => moduleExports);
});

// Admin 
const PropertyType = lazy(() => {
    return Promise.all([
        import("../views/admin/propertyType"),
        new Promise(resolve => setTimeout(resolve, delayTime))
    ])
        .then(([moduleExports]) => moduleExports);
});


const Page404 = lazy(() => {
    return Promise.all([
        import("../views/pageNotFound"),
        new Promise(resolve => setTimeout(resolve, delayTime))
    ])
        .then(([moduleExports]) => moduleExports);
});

const IndexRouter: React.FC = (): ReactElement => {
    return (
        <>
            <Router history={history}>
                <Suspense fallback={<NagistarLoading />}>
                    <Switch>
                        <Route path="/" exact component={Home} /> 
                        <Route path="/dashboard" exact component={Dashboard} /> 
                        <Route path="/notification" exact component={Notification} /> 
                        <Route path="/messages" exact component={Messages} />
                        <Route path="/profile" exact component={Profile} />
                        <Route path="/yourproperty" exact component={YourProperty} /> 
                        <Route path="/login" exact component={Login} />
                        <Route path="/register" exact component={Register} />
                        <Route path="/forgotpassword" exact component={ForgotPassword} />
                        <Route path="/resetPassword" exact component={ResetPassword} />
                        {/* Admin  */}
                        <Route path="/admin/propertyType" exact component={PropertyType} />

                        <Route path="/404" component={Page404} />
                        <Redirect to="/404" />
                    </Switch>
                </Suspense>
            </Router>
            <GlobalSpinner />
        </>
    );
};

export default IndexRouter;