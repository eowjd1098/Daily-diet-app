"""Server URL Configuration

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/1.10/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  url(r'^$', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  url(r'^$', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.conf.urls import url, include
    2. Add a URL to urlpatterns:  url(r'^blog/', include('blog.urls'))
"""
from django.conf.urls import include,url
from rest_framework import routers
from Server import views
from Rest_api.views import member_api

router = routers.DefaultRouter()
router.register(r'user',views.UserViewSet)
router.register(r'groups',views.GroupViewSet)

urlpatterns = [
    url(r'^',include(router.urls)),
    url(r'^api-auth/',include('rest_framework.urls')),
    url(r'^api/member/',member_api.as_view()),
]
