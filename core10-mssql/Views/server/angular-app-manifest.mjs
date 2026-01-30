
export default {
  bootstrap: () => import('./main.server.mjs').then(m => m.default),
  inlineCriticalCss: true,
  baseHref: '/',
  locale: undefined,
  routes: [
  {
    "renderMode": 2,
    "route": "/"
  },
  {
    "renderMode": 2,
    "route": "/static"
  },
  {
    "renderMode": 2,
    "route": "/about"
  },
  {
    "renderMode": 2,
    "route": "/contact"
  },
  {
    "renderMode": 2,
    "route": "/profile"
  },
  {
    "renderMode": 2,
    "route": "/productlist"
  },
  {
    "renderMode": 2,
    "route": "/productcatalog"
  },
  {
    "renderMode": 2,
    "route": "/productsearch"
  },
  {
    "renderMode": 2,
    "route": "/productreport"
  },
  {
    "renderMode": 2,
    "route": "/saleschart"
  },
  {
    "renderMode": 2,
    "route": "/**"
  }
],
  entryPointToBrowserMapping: undefined,
  assets: {
    'index.csr.html': {size: 9743, hash: '0eb0abcaa88912c895132c14942ac4c2776446fffbe074ab5fb285daa3cce964', text: () => import('./assets-chunks/index_csr_html.mjs').then(m => m.default)},
    'index.server.html': {size: 1059, hash: '641f23ec0f5e9da8838a2825196360607ce70903c8345136823d76dc0e7c7fa7', text: () => import('./assets-chunks/index_server_html.mjs').then(m => m.default)},
    'static/index.html': {size: 42005, hash: 'a299e63131a6924dbb34509ac89b573459b7ae3be661ae05d400832f076dfdec', text: () => import('./assets-chunks/static_index_html.mjs').then(m => m.default)},
    'index.html': {size: 54006, hash: '78834467b5ee043a9ac992b445853fb42130b984e5d3f7c9ac95b4cfc8eb97f8', text: () => import('./assets-chunks/index_html.mjs').then(m => m.default)},
    'productsearch/index.html': {size: 47318, hash: '04ccbb053f38bf1c58c4dae5b6bee12b1b3e5bea73552aaab6e4084fce87930b', text: () => import('./assets-chunks/productsearch_index_html.mjs').then(m => m.default)},
    'contact/index.html': {size: 47221, hash: '7812bc111c6cd7c2527a01f4210797bf52708e2d9cbae91c35fb408d71e28e0f', text: () => import('./assets-chunks/contact_index_html.mjs').then(m => m.default)},
    'saleschart/index.html': {size: 41579, hash: 'aac3bae371fd261ee4819549c128e1fd8f61f22a1d50a71d67df66b407d1471b', text: () => import('./assets-chunks/saleschart_index_html.mjs').then(m => m.default)},
    'about/index.html': {size: 47754, hash: 'f2e861273caf81b656b8d30f1159054b363bb2b0ad012874eef7984fa19a8ab5', text: () => import('./assets-chunks/about_index_html.mjs').then(m => m.default)},
    'productcatalog/index.html': {size: 48237, hash: '5e737412b55b750e1102b56193d0bc0893441b86820a8eaa21a85c79fdbb2cc2', text: () => import('./assets-chunks/productcatalog_index_html.mjs').then(m => m.default)},
    'productreport/index.html': {size: 41585, hash: 'ef66237ed8f865f95dcae4176db1a7c496705694df462ce084bb67299cdaeac9', text: () => import('./assets-chunks/productreport_index_html.mjs').then(m => m.default)},
    'productlist/index.html': {size: 53153, hash: '0250f1ed8e2e68b54027ef2be5859fd33c62b5a8e1880cc3e672d426da04e89f', text: () => import('./assets-chunks/productlist_index_html.mjs').then(m => m.default)},
    'profile/index.html': {size: 61550, hash: '965292cad1b8d1a5ee9db883567d0b1d989c2c11a0f5fc5f7982fee30c8f7d12', text: () => import('./assets-chunks/profile_index_html.mjs').then(m => m.default)},
    'styles-3TD3YHK2.css': {size: 383328, hash: 'vqUxZXEylKI', text: () => import('./assets-chunks/styles-3TD3YHK2_css.mjs').then(m => m.default)}
  },
};
