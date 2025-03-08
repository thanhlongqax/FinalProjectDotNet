import React, { Fragment } from 'react';
// import components
import { publicRoute } from './routes';
import { BrowserRouter , Routes , Route } from 'react-router-dom';
import { DefaultLayout } from './layouts';
const App = () => {
  return (
    <React.StrictMode>
      <BrowserRouter>
        <Routes>
        {publicRoute.map((route , index ) => {
          let Layout = DefaultLayout;
          if(route.layout){
            Layout = route.layout;
          }
          else if(route.layout === null){
            Layout = Fragment;
          }
          const Page = route.component;
          return (
              <Route key={index} path={route.path} element={<Layout><Page /></Layout>}>
                {/* Cấu hình route con ở đây */}
                {route.children && route.children.map((childRoute, childIndex) => (
                  <Route key={childIndex} path={childRoute.path} element={ <Layout><Page /></Layout>} />
                ))}
              </Route>
            );
          })}
        </Routes>
      </BrowserRouter>
      </React.StrictMode>
  )
};

export default App;
