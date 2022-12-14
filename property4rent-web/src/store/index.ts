import { Action, configureStore, ThunkAction } from '@reduxjs/toolkit';
import { setupListeners } from '@reduxjs/toolkit/query'
import { AccountService, UserService } from '../services/account';
import { ChatService } from '../services/chat';
import { FileService } from '../services/fileService'; 
import { RefService } from '../services/refService';
import { TeamService } from '../services/team';
import { PropertyService } from '../services/property';
import userReducer from './userSlice';
export const store = configureStore({
    reducer: {
        currentUser: userReducer,
        // Add the generated reducer as a specific top-level slice 
        [AccountService.reducerPath]: AccountService.reducer,
        [UserService.reducerPath]: UserService.reducer, 
        [TeamService.reducerPath]: TeamService.reducer,
        [FileService.reducerPath]: FileService.reducer,
        [ChatService.reducerPath]: ChatService.reducer,
        [RefService.reducerPath]: RefService.reducer,
        [PropertyService.reducerPath]: PropertyService.reducer,
    },
    // Adding the api middleware enables caching, invalidation, polling,
    // and other useful features of `rtk-query`.
    middleware: (getDefaultMiddleware) => {
        return getDefaultMiddleware({ serializableCheck: false })
            .concat(AccountService.middleware)
            .concat(UserService.middleware) 
            .concat(TeamService.middleware)
            .concat(FileService.middleware)
            .concat(ChatService.middleware)
            .concat(RefService.middleware)
            .concat(PropertyService.middleware);
    }
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
    ReturnType,
    RootState,
    unknown,
    Action<string>
>;
setupListeners(store.dispatch)
