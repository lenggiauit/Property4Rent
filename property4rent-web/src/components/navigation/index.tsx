import React, { useEffect, useState } from 'react'
import { useLocation } from 'react-router-dom';
import * as bt from 'react-bootstrap';
import { Translation } from '../../components/translation/'
import { LanguageSelector } from '../languageSelector';
import { AppProvider } from '../../contexts/appContext';
import { getLoggedUser, hasPermission, hasPermissions, logout } from '../../utils/functions';
import { AnimationLogo } from '../animationLogo';
import { User } from '../../services/models/user';
import { PermissionKeys } from '../../utils/constants';
import { getSignalRHubConnection, StartSignalRHubConnection, StopSignalRHubConnection } from '../../services/chat';

type Props = {
    isPublic: boolean,
    navCssClass?: string,
    currentUser: User | null
}

const Navigation: React.FC<Props> = ({ isPublic, navCssClass, currentUser }) => {
    const location = useLocation();
    const signalRHubConnection = null;
    const [messageCount, setMessageCount] = useState<Number>(0);
    // Start onload 
     useEffect(() => {
        StartSignalRHubConnection(); 
        return () => {
            StopSignalRHubConnection();
        }
    }, []);
    useEffect(() => { 
        setTimeout(() => {
       const signalRHubConnection = getSignalRHubConnection(); 
        if (signalRHubConnection.state === 'Connected') {
            const currentUser = getLoggedUser();
            if(currentUser !=null){
                signalRHubConnection.send("checkNewMessages", currentUser.id);
                console.log("checkNewMessages");
            }
            signalRHubConnection.on("onHaveNewMessages", (count) => {
                setMessageCount(count);
                console.log(count);
            });
        } }, 1000);

        
    }, [signalRHubConnection]);
    return (
        <>
            <nav className={"navbar navbar-expand-lg navbar-dark " + (navCssClass ? navCssClass : "")}>
                <div className="container">

                    <div className="navbar-left mr-4">
                        <button className="navbar-toggler" type="button"><span className="navbar-toggler-icon"></span></button>
                        <a className="navbar-brand" href="/">
                            <AnimationLogo width={45} height={45} />
                        </a>
                    </div>
                    <section className="navbar-mobile ">
                        <span className="navbar-divider d-mobile-none"></span>
                       
                        <ul className="nav nav-navbar nav-text-normal mr-auto">
                            {/* <li>
                                <a className={`nav-link ${(location.pathname == '/') ? "active" : ""}`} href="/"><Translation tid="nav_home" /></a>
                            </li>  */}
                            <li>
                                <a className={`nav-link ${(location.pathname == '/findahouse') ? "active" : ""}`} href="/"><Translation tid="nav_findahouse" /></a>
                            </li> 

                        </ul>
                        <div className="justify-content-end">
                           <ul className="nav nav-navbar nav-text-normal mr-auto ">
                            
                            {currentUser != null
                                && (hasPermissions([PermissionKeys.CreateTemplateType, PermissionKeys.GetTemplate, PermissionKeys.GetTemplateType, PermissionKeys.UploadTemplate]))
                                && <>
                                    <li className="nav-item">
                                        <a className={`nav-link ${(location.pathname.indexOf('admin') != -1) ? "active" : ""}`} href="#"><Translation tid="nav_admin" /><span className="arrow"></span></a>
                                        <nav className="nav">
                                            <a className="nav-link" href="/admin/propertytype">Property Type</a>
                                            <a className="nav-link" href="/admin/propertylist">Property List</a>
                                            <a className="nav-link" href="/admin/userlist">User List</a>
                                        </nav>
                                    </li>
                                </>
                            }
 
                           {currentUser != null && <>
                                <li className="nav-item">
                                    <a className={`nav-link ${(location.pathname.indexOf('notification') != -1) ? "active" : ""}`} href="/notification">
                                        <i className="bi bi-bell" style={{fontSize: 24}}></i>
                                    </a>
                                </li>
                                <li className="nav-item">  
                                        <a className={`nav-link ${(location.pathname.indexOf('messages') != -1) ? "active" : ""}`} href="/messages">
                                            
                                        <i className="bi bi-chat-text" style={{fontSize: 24}}></i>

                                        {messageCount == 0 ? "" : <> ({ messageCount})</>  }</a>
                                </li> 
                                <li className="nav-item">
                                    <a className={`nav-link ${(location.pathname.indexOf('user') != -1) ? "active" : ""}`} href="#"> 
                                    <i className="bi bi-person-circle" style={{fontSize: 24}}></i></a>
                                    <nav className="nav">
                                        <a className="nav-link" href="/profile"><Translation tid="nav_profile" /> </a>
                                        <a className="nav-link" href="/propertylist">Your Property</a>
                                        <a className="nav-link" href="#" onClick={() => logout()}><Translation tid="nav_logout" /></a>
                                    </nav>
                                </li> 
                            </>
                            }
                           </ul> 
                           </div>
                            {isPublic && currentUser == null && <> 
                            <a className="btn btn-sm btn-success" href="/login"><Translation tid="nav_login" /></a> 
                            <span className="navbar-divider d-mobile-none"></span>
                            </>}
                         
                        <LanguageSelector />
                    </section>

                </div>
            </nav>
        </>
    )
};

export default Navigation;