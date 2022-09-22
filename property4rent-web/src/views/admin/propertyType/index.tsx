import React, { ReactElement } from 'react';
import { useSelector } from 'react-redux';
import { Redirect } from 'react-router-dom';
import AdminLayout from '../../../components/adminLayout';
import * as bt from 'react-bootstrap'; 
import PropertyTypeList from '../../../components/propertyType/list';


const PropertyType: React.FC = (): ReactElement => {

    return (
        <>
            <AdminLayout>
                <PropertyTypeList />
            </AdminLayout>
        </>
    );
}

export default PropertyType;