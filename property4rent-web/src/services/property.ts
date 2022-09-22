import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { ApiRequest, ApiResponse, AppSetting } from "../types/type";
import { getLoggedUser } from '../utils/functions';
import * as FormDataFile from "form-data";
import { PropertyType } from './models/propertyType';
import { Property } from './models/property';

let appSetting: AppSetting = require('../appSetting.json');

export const PropertyService = createApi({
    reducerPath: 'PropertyService',

    baseQuery: fetchBaseQuery({
        baseUrl: appSetting.BaseUrl,
        prepareHeaders: (headers) => {
            const currentUser = getLoggedUser();
            // Add token to headers
            if (currentUser && currentUser.accessToken) {
                headers.set('Authorization', `Bearer ${currentUser.accessToken}`);
            }
            return headers;
        },
    }),
    endpoints: (builder) => ({
        GetPropertyTypes: builder.mutation<ApiResponse<PropertyType[]>, ApiRequest<{ isArchived: boolean }>>({
            query: (payload) => ({
                url: 'Property/getPropertyTypes',
                method: 'post',
                body: payload
            }),
            transformResponse(response: ApiResponse<PropertyType[]>) {
                return response;
            },
        }),
        GetQueryPropertyTypes: builder.query<ApiResponse<PropertyType[]>, ApiRequest<{ isArchived: boolean }>>({
            query: (payload) => ({
                url: 'Property/getPropertyTypes',
                method: 'post',
                body: payload
            }),
            transformResponse(response: ApiResponse<PropertyType[]>) {
                return response;
            },
        }),
        CreateEditPropertyType: builder.mutation<ApiResponse<PropertyType>, ApiRequest<{ id: any, name: any, description: any, isArchived: boolean }>>({
            query: (payload) => ({
                url: 'Property/createEditPropertyType',
                method: 'post',
                body: payload
            }),
            transformResponse(response: ApiResponse<PropertyType>) {
                return response;
            },
        }),
        GetPropertys: builder.mutation<ApiResponse<Property[]>, ApiRequest<{ isArchived: boolean }>>({
            query: (payload) => ({
                url: 'Property/getPropertys',
                method: 'post',
                body: payload
            }),
            transformResponse(response: ApiResponse<Property[]>) {
                return response;
            },
        }),

        CreateEditProperty: builder.mutation<ApiResponse<Property>, ApiRequest<{ id: any, PropertyTypeId: any, name: any, image: any, description: any, package: any, isArchived: boolean }>>({
            query: (payload) => ({
                url: 'Property/createEditProperty',
                method: 'post',
                body: payload
            }),
            transformResponse(response: ApiResponse<Property>) {
                return response;
            },
        }),

        GetPropertysByFilter: builder.mutation<ApiResponse<Property[]>, ApiRequest<{ typeId?: any }>>({
            query: (payload) => ({
                url: 'Property/getPropertysByFilter',
                method: 'post',
                body: payload
            }),
            transformResponse(response: ApiResponse<Property[]>) {
                return response;
            },
        }),

        GetPropertysById: builder.mutation<ApiResponse<Property>, ApiRequest<{ id: any }>>({
            query: (payload) => ({
                url: 'Property/getPropertysById',
                method: 'post',
                body: payload
            }),
            transformResponse(response: ApiResponse<Property>) {
                return response;
            },
        }),

    })
});

export const { useGetPropertyTypesMutation,
    useCreateEditPropertyTypeMutation,
    useCreateEditPropertyMutation,
    useGetPropertysMutation,
    useGetQueryPropertyTypesQuery,
    useGetPropertysByFilterMutation,
    useGetPropertysByIdMutation } = PropertyService;