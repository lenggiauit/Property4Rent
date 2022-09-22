import { ReactElement } from "react";
import Layout from "../../components/layout";
import { AppSetting } from "../../types/type";

const appSetting: AppSetting = require('../../appSetting.json');

const Notification: React.FC = (): ReactElement => {

    return(<>
            <Layout>
                <div className="container height-100vh-60px">
                    <div className="row h-100">

                        <h2>Notification</h2>
                    </div>
                </div>
            </Layout>
    </>)

}

export default Notification;