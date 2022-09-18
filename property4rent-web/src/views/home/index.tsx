import React, { ReactElement } from 'react';
import { useSelector } from 'react-redux';
import { Redirect } from 'react-router-dom';
import Layout from '../../components/layout';
import { selectUser } from "../../store/userSlice";
import { decrypt } from '../../utils/crypter';
import { getLoggedUser } from '../../utils/functions';
import * as bt from 'react-bootstrap';
import Footer from '../../components/footer';
import SearchBox from '../../components/searchBox';


const Home: React.FC = (): ReactElement => {

    return (
        <>
            <Layout isPublic={true}>

                {/* <header className="header h-fullscreen-nav-none mt-8" >
                    <div className="container">
                        <div className="row align-items-center ">

                            

                        </div>
                    </div>
                </header> */}
                <div className="container search-box">
                    <div className="row">
                        <div className="col align-self-end text-center ">
                            <SearchBox />
                        </div>
                    </div>
                </div>
                <Footer />
            </Layout>

        </>
    );
}

export default Home;